using _01Burliai.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace _01Burliai.Repositories
{
    class FileRepository
    {
        public static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Burliai", "04Burliai");
        private ObservableCollection<Person> _persons = new ObservableCollection<Person>();

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set { _persons = value; }
        }

        public FileRepository()
        {
            if (!Directory.Exists(BaseFolder))
            {
                Directory.CreateDirectory(BaseFolder);
                FillUsers();
                return;
            }
            LoadUsersAsync();
        }

        public async Task AddOrUpdateAsync(Person person)
        {
            string str = JsonSerializer.Serialize(person);

            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, person.Name + "_" + person.Surname), false))
            {
                await sw.WriteAsync(str);
            }
        }

        public async Task<Person> GetAsync(string filepath)
        {
            string str = null;

            if (!File.Exists(filepath))
                return null;

            using (StreamReader sr = new StreamReader(filepath))
            {
                str = await sr.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<Person>(str);
        }

        public void Remove(Person person)
        {
            string filepath = Path.Combine(BaseFolder, person.Name + "_" + person.Surname);

            if (!File.Exists(filepath))
                return;

            File.Delete(filepath);
        }

        private async void FillUsers()
        {
            _persons.Add(new Person("Danylo", "Burliai", "colossus00x@icloud.com", new DateTime(2003,01,13)));
            _persons.Add(new Person("Serhii", "Tarasenko", "doom@i.ua", new DateTime(2003, 07, 11)));
            _persons.Add(new Person("Mykhailo", "Nesterenko", "ktp@gmail.com", new DateTime(2003, 03, 19)));
            _persons.Add(new Person("Maksim", "Burliai", "melkii@gmail.com", new DateTime(2010, 05, 12)));
            _persons.Add(new Person("Maria", "Burliai", "kity@gmail.com", new DateTime(2007, 06, 20)));
            foreach (Person p in _persons)
                await AddOrUpdateAsync(p);
        }

        private async void LoadUsersAsync()
        {
            string[] files = Directory.GetFiles(BaseFolder);
            foreach(string name in files)
            {
                _persons.Add(await GetAsync(name));
            }
        }
    }
}
