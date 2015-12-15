using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entity;

namespace DataAccess.Repository
{
    public class StudentRepository :Repository<Student>, IStudentRepository
    {
       
    }
}
