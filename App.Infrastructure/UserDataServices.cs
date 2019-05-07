﻿using App.Core.Entities;
using App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Infrastructure.Services
{
    public class UserDataServices : IUserDataServices
    {
        public GZContext _dbContext { get; }

        public UserDataServices(GZContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }

            _dbContext.Set<User>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _dbContext.Set<User>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public User GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id needs to be defined");
            }

            return _dbContext.Set<User>().SingleOrDefault(e => e.Id.Equals(id));
        }

        public User GetUserByName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("UserName needs to be defined");
            }

            return _dbContext.Set<User>().SingleOrDefault(e => e.UserName.Equals(userName));
        }

        public List<User> List()
        {
            return _dbContext.Set<User>().ToList();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public bool UserNameUsed(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("UserName needs to be defined");
            }

            return _dbContext.Set<User>().Any(e => e.UserName.Equals(userName));
        }
    }
}
