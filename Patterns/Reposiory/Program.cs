﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Reposiory
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    
    // CRUD (Creat, Read, Update, Delete)
    interface IRepository<T> where T : class
    {
        // Create
        void Create(T item); 

        // Read
        T Get(string id);
        IEnumerable<T> GetAll();

        // Update
        void Update(string id, T item);

        // Delete
        void Delete(string id);
    }

    abstract class Repository<T> : IRepository<T> where T : class
    {
        static protected Dictionary<string, T> storage;
        public abstract void Create(T item);

        public T Get(string id)
        {
            storage.TryGetValue(id, out T item);
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            return storage.Select(x => x.Value);
        }

        public void Update(string id, T item)
        {
            storage[id] = item;
        }
        public void Delete(string id)
        {
            storage.Remove(id);
        }
    }

    class ClientRepository : Repository<Client>
    {
        public override void Create(Client item)
        {
            storage.Add(item.Id, item);
        }
    }

    class CardRepository : Repository<Card>
    {
        public override void Create(Card item)
        {
            storage.Add(item.Number, item);

        }
    }

    class Client
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
    }

    class Card
    {
        public string ClientId { get; set; }
        public string Number { get; set; }
        public string Pin { get; set; }
        public decimal Balance { get; set; }
    }

}
