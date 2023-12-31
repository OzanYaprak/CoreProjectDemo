﻿using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void Add(T t);

        void Update(T t);

        void Delete(T t);

        List<T> GetAll();

        T GetByID(int id);
    }
}