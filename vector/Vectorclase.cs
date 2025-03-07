using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace vector
{
    class Vectorclase
    {
        private const int max = 10000;
        private int longitud;
        private int[] elementos;
        public Vectorclase(int longitud)
        {
            elementos = new int[max];
            this.longitud = longitud;
        }

        public void modificarlongitud(int nuevalongitud)
        {
            longitud = nuevalongitud;
        }
        public int obtenerlongitud()
        {
            return longitud;
        }
        public void ponerelemento(int posicion, int valor)
        {
            if (posicion > longitud)
            {
                Console.WriteLine("Posicion no valida");
            }
            else
            {
                elementos[posicion] = valor;
            }
        }
        public int obtenerelemento(int pos)
        {
            return elementos[pos];
        }

        public void selectionsort()
        {
            for (int i = 0; i < longitud; i++)
            {
                int minimo = i;
                for (int j = i + 1; j < longitud; j++)
                {
                    if (elementos[minimo] > elementos[j])
                    {
                        minimo = j;
                    }

                }
                int temp = elementos[minimo];
                elementos[minimo] = elementos[i];
                elementos[i] = temp;

            }

        }
        public void insertinsort()
        {
            for (int i = 0; i < longitud; i++)
            {
                for (int j = i; j > 0 && elementos[j] < elementos[j - 1]; j--)
                {
                    int temp = elementos[j];
                    elementos[j] = elementos[j - 1];
                    elementos[j - 1] = temp;
                }
            }

        }
        public void Mergesort(int left = 0, int right = -20)
        {
            if (right == -20)
            {
                right = longitud - 1;
            }
            if (left < right)
            {
                int mid = (left + right) / 2;
                Mergesort(left, mid);
                Mergesort(mid + 1, right);
                Merge(left, mid, right);
            }


        }

        private void Merge(int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            for (int i = 0; i < n1; i++)
                leftArray[i] = elementos[left + i];
            for (int j = 0; j < n2; j++)
                rightArray[j] = elementos[mid + 1 + j];
            int iLeft = 0, iRight = 0, k = left;
            while (iLeft < n1 && iRight < n2)
            {
                if (leftArray[iLeft] <= rightArray[iRight])
                {
                    elementos[k] = leftArray[iLeft];
                    iLeft++;
                }
                else
                {
                    elementos[k] = rightArray[iRight];
                    iRight++;
                }
                k++;
            }

            while (iLeft < n1)
            {
                elementos[k] = leftArray[iLeft];
                iLeft++;
                k++;
            }

            while (iRight < n2)
            {
                elementos[k] = rightArray[iRight];
                iRight++;
                k++;
            }
        }

        public void insertarelemento(int pos, int valor)
        {
            if (pos == longitud)
            {
                elementos[longitud] = valor;
                longitud = longitud + 1;

            }
            else
            {
                int temp = elementos[pos];
                elementos[pos] = valor;
                insertarelemento(pos + 1, temp);

            }
        }
        public void eliminar(int pos)
        {
            if (pos > longitud)
            {
                longitud = longitud - 1;
            }
            else
            {
                elementos[pos] = elementos[pos + 1];
                eliminar(pos + 1);
            }

        }
        public bool comparar(Vectorclase vector2)
        {
            if (longitud != vector2.obtenerlongitud())
            {
                return false;
            }
            else
            {
                for (int i = 0; i < longitud; i++)
                {
                    if (elementos[i] != vector2.obtenerelemento(i))
                    {
                        return false;
                    }

                }
                return true;

            }


        }
    


        public void Union(Vectorclase vector2)
        {
            for (int i = 0; i < vector2.obtenerlongitud(); i++)
            {
                elementos[longitud] = vector2.obtenerelemento(i);
                longitud++;
            }
            Eliminarduplicados(longitud-vector2.obtenerlongitud());


        }
        public bool Subconjunto(Vectorclase vector2) {
            bool subconjunto = false;
            if (vector2.obtenerlongitud() > longitud)
            {
                return false;
            }
            
            for (int i = 0; i < longitud; i++)
            {    int j = 0;
                if (elementos[i] == vector2.obtenerelemento(j))
                {
                    for (j = 0;  j< vector2.obtenerlongitud(); j++)
                    {
                        if (elementos[i+j] != vector2.obtenerelemento(j))
                        {
                            subconjunto = false; 
                            break; 
                        }
                        else
                        {
                            subconjunto = true;
                        }
                    }
                    if (subconjunto == true)
                    {
                        return subconjunto; 
                    }

                }
            }
            return false; 
        }
        
        private void Eliminarduplicados(int inicio)
        {
            for (int i = 0; i < inicio; i++)
            {
                for (int j = inicio; j < longitud; j++)
                {
                    if (elementos[i] == elementos[j])
                    {
                        eliminar(j);
                        j = j - 1;
                    }

                }

            }

        }


        public void Eliminarduplicados()
        {
            for (int i = 0; i < longitud; i++)
            {
                for (int j = i+1; j < longitud; j++)
                {
                    if (elementos[i] == elementos[j]) 
                    {
                        eliminar(j);
                        j = j - 1;
                    }
                    
                }

            }

        }

    }
}

