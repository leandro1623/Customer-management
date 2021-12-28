using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_clientes
{
    public sealed class DataBase
    {
        public string Path { get; private set; }
        
        public DataBase(string path)
        {
            this.Path = path;
        }

        ~DataBase()
        {
            //Destructor
        }

        /// <summary>
        /// Agrega texto al archivo
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool Add(string create,string createDate,string name,string lastName,string address)
        {
            System.Text.StringBuilder content = new StringBuilder();
            content.Append(create);
            content.Append(";");
            content.Append(createDate);
            content.Append(";");
            content.Append(name);
            content.Append(";");
            content.Append(lastName);
            content.Append(";");
            content.Append(address);
            


            System.IO.File.AppendAllText(Path,content+System.Environment.NewLine);
            return System.IO.File.Exists(Path) ? true : false;
        }

        public bool Add(params string[] content)
        {
            System.IO.File.AppendAllLines(Path, content);
            //System.IO.File.AppendAllText(Path, System.Environment.NewLine);
            return System.IO.File.Exists(Path) ? true : false;
        }

        /// <summary>
        /// Borra el archivo
        /// </summary>
        public void DeleteFile()
        {
            System.IO.File.Delete(this.Path);
        }


        /// <summary>
        /// Elimina todo el texto del archivo
        /// </summary>
        public void DeleteAlltextInFile()
        {
            this.DeleteFile();
            System.IO.File.Create(this.Path);
        }

        /// <summary>
        /// Elimina una linea en espcifico
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public void DeleteEspecificLine(int index)
        {
            string[] cont = System.IO.File.ReadAllLines(this.Path);
            string[] result=new string[cont.Length-1];

            for(int i = 0; i < cont.Length; i++)
            {
                if (i != index)
                {
                    result[i] = cont[i];
                }
            }
            this.DeleteFile();
            this.Add(result);
        }

        public void RecreateDataBase(List<Customer> list)
        {
            System.IO.File.Delete(Path);
            foreach(Customer _Customer in list)
            {
                this.Add(_Customer.Create.ToString(), _Customer.CreateDate.ToLongDateString(), _Customer.Name, _Customer.LastName, _Customer.Address);
            }
        }
    }
}
