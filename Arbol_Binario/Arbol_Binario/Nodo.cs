using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Arbol_Binario
{
    class Nodo
    {
        //esta es una clase autoreferenciada
        #region atributos
        private string name;
        private sbyte age;
        private Image picture;
        //Aqui empizan las autoreferencias
        private Nodo hijoIzquierdo;
        private Nodo hijoDerecho;


        #endregion
        #region constructor
        public Nodo(string name, sbyte age, Image picture)//Cada vez que cree una instancia de la clase va a recibir de parametro el nombre y la edad.
        {
            this.name = name;
            this.age = age;
            this.hijoIzquierdo = null;//se inicializa para hacer las comprovaciones, despues se utilizan las propiedades para asignarle hijos 
            this.hijoDerecho = null;
            this.picture = picture;
        }


        public Nodo()
        {
            this.name = "-";
            this.age = -1;
            this.picture = null;
            this.hijoIzquierdo = null;
            this.hijoDerecho = null;
        }
        #endregion
        #region propiedades
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Trim().Length > 0)//quita los espacios por si en una caja de texto el usuario la caja
                {
                    this.name = value;
                }
                else
                {
                    this.name = "Sin Nombre";
                }

            }
        }
        public sbyte Age
        {
            get { return this.age; }
            set
            {
                if (value > 0)//Aqui no se le puede poner trimp, asi que solo lo igualamos a 0
                {
                    this.age = value;
                }
                else
                {
                    this.age = -1;
                }

            }
        }
        public Nodo HijoIzquierdo
        {
            get { return this.hijoIzquierdo; }
            set { this.hijoIzquierdo = value; }
        }
        public Nodo HijoDerecho
        {
            get { return this.hijoDerecho; }
            set { this.hijoDerecho = value; }
        }
        public Image Picture
        {
            get { return this.picture; }
            set { this.picture = value; }
        }

        #endregion
    }
}
