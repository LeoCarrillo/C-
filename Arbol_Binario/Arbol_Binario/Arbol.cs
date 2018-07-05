using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace Arbol_Binario
{
    class Arbol
    {

        #region atributos
        private DataTable resultado;
        private Nodo raiz;
        #endregion
        #region constructor
        int y = 0;
        public Arbol()
        {
            this.raiz = null;
            this.resultado = new DataTable();//cuando creamos un objeto de tipo arbol, se crea una tabla
            //estructura de la tabla, se crean solo las columnas;
            resultado.Columns.Add("name", typeof(string));
            resultado.Columns.Add("age", typeof(sbyte));
            resultado.Columns.Add("foto", typeof(Image));
        }
        #endregion
        #region metodos
        public void insertarNodo(string name, sbyte age, Image foto)
        {
            //llamar a metodo privado insertarNodo
            insertarNodo(name, age, foto, raiz);

        }
        private Nodo insertarNodo(string name, sbyte age, Image foto, Nodo nodo)
        {
            //se hace el caso base, porque el nodo recibe la raiz.
            if (nodo == null)//si la raiz esta apuntando a nodo es porque se esta creando el arbol
            {
                Nodo nuevoN = new Nodo(name, age, foto);
                nodo = nuevoN;
                if (raiz == null)
                {
                    raiz = nuevoN;
                }
            }
            else if (age < nodo.Age)
            {
                nodo.HijoIzquierdo = insertarNodo(name, age, foto, nodo.HijoIzquierdo);
            }
            else if (age > nodo.Age)
            {
                nodo.HijoDerecho = insertarNodo(name, age, foto, nodo.HijoDerecho);
            }
            return nodo;
        }
        public DataTable recorrerPreOrden()
        {
            resultado.Clear();
            if (raiz == null)
            {
                return null;
            }
            return recorrerPreOrden(raiz);
        }
        private DataTable recorrerPreOrden(Nodo nodo)
        {
            //la clave es rescatar la raiz, porque es raiz izquierda derecha
            DataRow r = resultado.NewRow();
            r["name"] = nodo.Name;
            r["age"] = nodo.Age;
            r["foto"] = nodo.Picture;
            resultado.Rows.Add(r);
            if (nodo.HijoIzquierdo != null)//pregunta si el nodo tiene una raiz
            {//recursuvudad
                recorrerPreOrden(nodo.HijoIzquierdo);//este metodo se manda a llamar a si mismo, es como un ciclo for
            }
            if (nodo.HijoDerecho != null)//pregunta si el nodo tiene una raiz
            {//recursuvudad
                recorrerPreOrden(nodo.HijoDerecho);//este metodo se manda a llamar a si mismo, es como un ciclo for
            }

            return resultado;
        }
        public DataTable recorrerInOrden()
        {
            resultado.Clear();
            if (raiz == null)
            {
                return null;
            }
            return recorrerInOrden(raiz);

        }
        private DataTable recorrerInOrden(Nodo nodo)
        {


            if (nodo.HijoIzquierdo != null)
            {
                recorrerInOrden(nodo.HijoIzquierdo);
            }
            DataRow r = resultado.NewRow();
            r["name"] = nodo.Name;
            r["age"] = nodo.Age;
            r["foto"] = nodo.Picture;
            resultado.Rows.Add(r);
            if (nodo.HijoDerecho != null)
            {
                recorrerInOrden(nodo.HijoDerecho);
            }

            return resultado;
        }

        public DataTable recorrerPostOrden()
        {
            resultado.Clear();
            if (raiz == null)
            {
                return null;
            }
            return recorrerPostOrden(raiz);

        }
        private DataTable recorrerPostOrden(Nodo nodo)
        {


            if (nodo.HijoIzquierdo != null)
            {
                recorrerPostOrden(nodo.HijoIzquierdo);
            }
            if (nodo.HijoDerecho != null)
            {
                recorrerPostOrden(nodo.HijoDerecho);
            }
            DataRow r = resultado.NewRow();
            r["name"] = nodo.Name;
            r["age"] = nodo.Age;
            r["foto"] = nodo.Picture;
            resultado.Rows.Add(r);

            return resultado;
        }

        public Nodo recorrerBuscar(string nom)
        {
            resultado.Clear();
            if (raiz == null)
            {
                return null;
            }
            return recorrerBuscar(raiz, nom);

        }
        private Nodo recorrerBuscar(Nodo nodo, string nom)
        {
            if (nodo.HijoIzquierdo != null)
            {
                if (nodo.HijoIzquierdo.Name == nom)
                {
                    DataRow r = resultado.NewRow();
                    r["name"] = nodo.HijoIzquierdo.Name;
                    r["age"] = nodo.HijoIzquierdo.Age;
                    r["foto"] = nodo.HijoIzquierdo.Picture;
                    resultado.Rows.Add(r);
                    return nodo.HijoIzquierdo;
                }
                recorrerBuscar(nodo.HijoIzquierdo, nom);
            }
            if (nodo.HijoDerecho != null)
            {
                if (nodo.HijoDerecho.Name == nom)
                {
                    DataRow r = resultado.NewRow();
                    r["name"] = nodo.HijoDerecho.Name;
                    r["age"] = nodo.HijoDerecho.Age;
                    r["foto"] = nodo.HijoDerecho.Picture;
                    resultado.Rows.Add(r);
                    return nodo.HijoDerecho;
                }
                recorrerBuscar(nodo.HijoDerecho, nom);
            }
            if (nodo.Name == nom)
            {
                DataRow r = resultado.NewRow();
                r["name"] = nodo.Name;
                r["age"] = nodo.Age;
                r["foto"] = nodo.Picture;
                resultado.Rows.Add(r);
                return nodo;
            }
            else
            {
                return null;
            }

        }

        public Nodo recorrer(string name, sbyte age, Image foto)
        {
            resultado.Clear();
            if (raiz == null)
            {
                return null;
            }
            return recorrer(raiz, name, age, foto);

        }
        private Nodo recorrer(Nodo nodo, string name, sbyte age, Image foto)
        {
            if (nodo.HijoIzquierdo != null)
            {
                if (nodo.HijoIzquierdo.Name == name)
                {
                    modificarNodo(nodo.HijoIzquierdo, name, age, foto);
                }
                recorrer(nodo.HijoIzquierdo, name, age, foto);
            }
            if (nodo.HijoDerecho != null)
            {
                if (nodo.HijoDerecho.Name == name)
                {
                    modificarNodo(nodo.HijoDerecho, name, age, foto);
                    //nodo.HijoDerecho.Name, nodo.HijoDerecho.Age, nodo.HijoDerecho.Picture
                }
                recorrer(nodo.HijoDerecho, name, age, foto);
            }
            if (nodo.Name == name)
            {
                modificarNodo(nodo, name, age, foto);
            }
            else
            {
                return null;
            }
            return nodo;
        }
        private Nodo modificarNodo(Nodo nodo, string name, sbyte age, Image foto)
        {
            nodo.Age = age;
            nodo.Picture = foto;
            nodo.Name = name;
            return nodo;
        }

        public Nodo recorrerElin(string name)
        {
            resultado.Clear();
            if (raiz == null)
            {
                return null;
            }
            return recorrerElin(raiz, name);

        }
        private Nodo recorrerElin(Nodo nodo, string name)
        {
            if (nodo.HijoIzquierdo != null)
            {
                if (nodo.HijoIzquierdo.Name == name)
                {
                    elim(nodo.HijoIzquierdo, nodo.HijoIzquierdo.Name, nodo.HijoIzquierdo.Age, nodo.HijoIzquierdo.Picture);
                }
                recorrerElin(nodo.HijoIzquierdo, name);
            }
            if (nodo.HijoDerecho != null)
            {
                if (nodo.HijoDerecho.Name == name)
                {
                    elim(nodo.HijoDerecho, nodo.HijoDerecho.Name, nodo.HijoDerecho.Age, nodo.HijoDerecho.Picture);
                }
                recorrerElin(nodo.HijoDerecho, name);
            }
            if (nodo.Name == name)
            {
                elim(nodo, nodo.Name, nodo.Age, nodo.Picture);
            }
            else
            {
                return null;
            }
            return nodo;
        }
        private Nodo elim(Nodo nodo, string name, sbyte age, Image foto)
        {
            nodo = null;
            return nodo;
        }


        #endregion
    }
}
