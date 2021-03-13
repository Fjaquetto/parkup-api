using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Domain.Interfaces
{
    public interface IQueryBase
    {
        string Add();
        string GetById();
        string GetAll();
        string GetByFilter();
        string Remove();
        string Update();
    }
}
