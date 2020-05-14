using EmpSys.Data;
using EmpSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpSys.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EmpContext context)
        {
            //Look for any Areas
            if (context.Areas.Any())
            {
                return;  //DB has been seeded
            }

            var areas = new Area[]
            {
                new Area{name= "Adminstração"},
                new Area{name= "Recursos Humanos"},
                new Area{name= "Contabilidade"},
                new Area{name= "Tecnologia da Informação"}
            };

            context.Areas.AddRange(areas);
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee{AreaID=1, name= "Rennan Fulaninho", cpf="123.123.412-12", dateBirth=DateTime.Parse("2018-09-01"), paycheck=312.80m, payment=false, Gender=Gender.M},
                new Employee{AreaID=1, name= "Senhora Beltrano", cpf="161.151.412-08", dateBirth=DateTime.Parse("2018-09-01"), paycheck=500.12m, payment=false, Gender=Gender.F},
                new Employee{AreaID=2, name= "Fulano Ciclano", cpf="123.112.412-12", dateBirth=DateTime.Parse("2018-09-01"), paycheck=800.12m, payment=false, Gender=Gender.M},
                new Employee{AreaID=3, name= "Senhor Dequalquer", cpf="123.111.412-12", dateBirth=DateTime.Parse("2018-09-01"), paycheck=312.12m, payment=false, Gender=Gender.M},
                new Employee{AreaID=4, name= "Tal DeAlgumLugar", cpf="154.123.412-13", dateBirth=DateTime.Parse("2018-09-01"), paycheck=112.12m, payment=false, Gender=Gender.M},
                new Employee{AreaID=4, name= "Alguma Graça", cpf="123.123.111-55", dateBirth=DateTime.Parse("2018-09-01"), paycheck=412.12m, payment=false, Gender=Gender.F},
                new Employee{AreaID=4, name= "Possível Beltrano", cpf="123.123.512-11", dateBirth=DateTime.Parse("2018-09-01"), paycheck=212.12m, payment=false, Gender=Gender.M},
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();

            var dependents = new Dependent[]
            {
                new Dependent{ID = 110,EmployeeID=1, name= "Rennan Fulaninho Jr", cpf="123.123.412-12", dateBirth=DateTime.Parse("2018-09-01"),  Gender=Gender.M},
                new Dependent{ID = 111,EmployeeID=1, name= "Senhora Fulaninho", cpf="161.151.412-08", dateBirth=DateTime.Parse("2018-09-01"),  Gender=Gender.F},
                new Dependent{ID = 112,EmployeeID=2, name= "Fulano Beltrano", cpf="123.112.412-12", dateBirth=DateTime.Parse("2018-09-01"), Gender=Gender.M},
                new Dependent{ID = 210,EmployeeID=3, name= "Senhor Ciclano", cpf="123.111.412-12", dateBirth=DateTime.Parse("2018-09-01"), Gender=Gender.M},
                new Dependent{ID = 310,EmployeeID=4, name= "Tal Dequalquer", cpf="154.123.412-13", dateBirth=DateTime.Parse("2018-09-01"), Gender=Gender.M},
                new Dependent{ID = 311,EmployeeID=4, name= "Alguma Dequalquer", cpf="123.123.111-55", dateBirth=DateTime.Parse("2018-09-01"), Gender=Gender.F},
                new Dependent{ID = 312,EmployeeID=4, name= "Possível Dequalquer", cpf="123.123.512-11", dateBirth=DateTime.Parse("2018-09-01"), Gender=Gender.M},
            };
            context.Dependents.AddRange(dependents);
            context.SaveChanges();
        }
    }
}
