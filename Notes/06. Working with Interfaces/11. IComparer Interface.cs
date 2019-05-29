// Multiple Sort Orders with IComparer
// ALLOWING SORTING BASED ON MORE THAN ONE VALKUE
// Unlike the IComparable interface, IComparer is typically not implemented on the type you are trying to
// sort (i.e., Employee). Rather, you implement this interface on any number of helper classes, one for each sort
// order (Name, ID,..etc). 

using System;
using System.Collections;

namespace Experiment {

    public class EmployeeComparerByName : IComparer {
        int IComparer.Compare(object o1, object o2) {
            Employee self = o1 as Employee;
            Employee other = o2 as Employee;
            if (self == null || other == null) {
                throw new ArgumentException("Argument Must Be Employees.");
            } else {
                return String.Compare(self.Name, other.Name);
            }
        }
    }
    public class Employee : IComparable {
        public string Name { get; set; }
        public int ID { get; set; }
        public Employee(string name, int id) {
            this.Name = name;
            this.ID = id;
        }

        int IComparable.CompareTo(object o) {
            Employee other = o as Employee;
            if (other != null) {
                if(this.ID > other.ID) {
                    return 1;
                } else if(this.ID < other.ID) {
                    return -1;
                } else {
                    return 0;
                }

                // SINCE INT TYPES IMPLEMENT ICOMPARABLE WE COULD DO THIS SIMPLY
                // return this.ID.CompareTo(other.ID);

            } else {
                throw new ArgumentException("Argument Must Be Employee.");
            }

            
        }

        public override string ToString() {
            return String.Format("ID: {0}, Name: {1}", this.ID, this.Name);
        }
    }   

    class Program {
        static void Main(string[] args) {
            Employee[] employees = {
                                       new Employee("Zippy", 21),
                                       new Employee("Sara", 32),
                                       new Employee("Bob", 1),
                                       new Employee("David", 27),
                                       new Employee("Alex", 4)
                                   };

           

            // NOW SORT BY NAME
            System.Array.Sort(employees, new EmployeeComparerByName());

            

            foreach (Employee e in employees) {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }
    }
}
 