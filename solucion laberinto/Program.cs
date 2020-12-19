//Ximena Caceres
//Bryan Flores
//Alberth Garcia

using System;
using System.Collections.Generic;
using System.Linq;

namespace CaceresFloresGarcia
{
    class Program
    {
        static List<int[]> CaminoCorrecto(int[,] laberinto, bool[,] yaRecorridos, Stack<int[]> camino, bool primerValor, bool resuelto)
        {
            List<int[]> solucion = new List<int[]>();

            if (camino.Count != 0)
            {
                //variables
                int[] inicio = camino.Pop();
                int[] siguiente;
                //selecciona el camino correcto

                //casos posibles
                List<int> arriba = new List<int> { 0, 1, 4, 5, 8, 9, 12, 13 };
                List<int> abajo = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
                List<int> izquierda = new List<int> { 0, 2, 4, 6, 8, 10, 12, 14 };
                List<int> derecha = new List<int> { 0, 1, 2, 3, 8, 9, 10, 11 };

                //caso base
                if (!(inicio[0] < 0 || inicio[0] >= laberinto.GetLength(0) || inicio[1] < 0 || inicio[1] >= laberinto.GetLength(1)))
                {
                    //caso general
                    if (arriba.Contains(laberinto[inicio[0], inicio[1]]) && resuelto == false)
                    {
                        //Determina el siguiente elemento
                        siguiente = new int[] { inicio[0] - 1, inicio[1] };

                        //se comprueba si el siguiente elemento es la solucion
                        if ((siguiente[0] > -1 && siguiente[1] > -1) && (siguiente[0] < laberinto.GetLength(0) && siguiente[1] < laberinto.GetLength(1)))
                        {

                            //se comprueba que el camino no se haya recorrido
                            if (!yaRecorridos[siguiente[0], siguiente[1]])
                            {
                                //marca como recorrido el camino
                                yaRecorridos[inicio[0], inicio[1]] = true;

                                //determina los elementos iniciales
                                camino.Push(siguiente);
                                solucion.Add(siguiente);

                                //lamada recursiva al siguiente elemento
                                solucion = new List<int[]>(solucion.Concat(CaminoCorrecto(laberinto, yaRecorridos, camino, false, false)));

                                //comprueba si el camino es correcto
                                if (solucion[solucion.Count() - 1][0] >= 0 && solucion[solucion.Count() - 1][0] < laberinto.GetLength(0))
                                {
                                    if (solucion[solucion.Count() - 1][1] >= 0 && solucion[solucion.Count() - 1][1] < laberinto.GetLength(0))
                                    {
                                        solucion.Clear();
                                    }
                                    else
                                    {
                                        resuelto = true;
                                    }
                                }
                                else
                                {
                                    resuelto = true;
                                }
                            }
                        }
                        else
                        {
                            solucion.Add(siguiente);
                            return solucion;
                        }
                    }
                    if (abajo.Contains(laberinto[inicio[0], inicio[1]]) && resuelto == false)
                    {
                        //Determina el siguiente elemento
                        siguiente = new int[] { inicio[0] + 1, inicio[1] };

                        //se comprueba si el siguiente elemento es la solucion
                        if ((siguiente[0] > -1 && siguiente[1] > -1) && (siguiente[0] < laberinto.GetLength(0) && siguiente[1] < laberinto.GetLength(1)))
                        {

                            //se comprueba que el camino no se haya recorrido
                            if (!yaRecorridos[siguiente[0], siguiente[1]])
                            {
                                //marca como recorrido el camino
                                yaRecorridos[inicio[0], inicio[1]] = true;

                                //determina los elementos iniciales
                                camino.Push(siguiente);
                                solucion.Add(siguiente);

                                //comprueba si el camino es correcto
                                solucion = new List<int[]>(solucion.Concat(CaminoCorrecto(laberinto, yaRecorridos, camino, false, false)));

                                if (solucion[solucion.Count() - 1][0] >= 0 && solucion[solucion.Count() - 1][0] < laberinto.GetLength(0))
                                {
                                    if (solucion[solucion.Count() - 1][1] >= 0 && solucion[solucion.Count() - 1][1] < laberinto.GetLength(0))
                                    {
                                        solucion.Clear();
                                    }
                                    else
                                    {
                                        resuelto = true;
                                    }
                                }
                                else
                                {
                                    resuelto = true;
                                }
                            }
                        }
                        else
                        {
                            solucion.Add(siguiente);
                            return solucion;
                        }
                    }
                    if (izquierda.Contains(laberinto[inicio[0], inicio[1]]) && resuelto == false)
                    {
                        //Determina el siguiente elemento
                        siguiente = new int[] { inicio[0], inicio[1] - 1 };

                        //se comprueba si el siguiente elemento es la solucion
                        if ((siguiente[0] > -1 && siguiente[1] > -1) && (siguiente[0] < laberinto.GetLength(0) && siguiente[1] < laberinto.GetLength(1)))
                        {

                            //se comprueba que el camino no se haya recorrido
                            if (!yaRecorridos[siguiente[0], siguiente[1]])
                            {
                                //marca como recorrido el camino
                                yaRecorridos[inicio[0], inicio[1]] = true;

                                //determina los elementos iniciales
                                camino.Push(siguiente);
                                solucion.Add(siguiente);

                                //comprueba si el camino es correcto
                                solucion = new List<int[]>(solucion.Concat(CaminoCorrecto(laberinto, yaRecorridos, camino, false, false)));

                                if (solucion[solucion.Count() - 1][0] >= 0 && solucion[solucion.Count() - 1][0] < laberinto.GetLength(0))
                                {
                                    if (solucion[solucion.Count() - 1][1] >= 0 && solucion[solucion.Count() - 1][1] < laberinto.GetLength(0))
                                    {
                                        solucion.Clear();
                                    }
                                    else
                                    {
                                        resuelto = true;
                                    }
                                }
                                else
                                {
                                    resuelto = true;
                                }
                            }
                        }
                        else
                        {
                            solucion.Add(siguiente);
                            return solucion;
                        }
                    }
                    if (derecha.Contains(laberinto[inicio[0], inicio[1]]) && resuelto == false)
                    {
                        //Determina el siguiente elemento
                        siguiente = new int[] { inicio[0], inicio[1] + 1 };

                        //se comprueba si el siguiente elemento es la solucion
                        if ((siguiente[0] > -1 && siguiente[1] > -1) && (siguiente[0] < laberinto.GetLength(0) && siguiente[1] < laberinto.GetLength(1)))
                        {

                            //se comprueba que el camino no se haya recorrido
                            if (!yaRecorridos[siguiente[0], siguiente[1]])
                            {
                                //marca como recorrido el camino
                                yaRecorridos[inicio[0], inicio[1]] = true;

                                //determina los elementos iniciales
                                camino.Push(siguiente);
                                solucion.Add(siguiente);

                                //comprueba si el camino es correcto
                                solucion = new List<int[]>(solucion.Concat(CaminoCorrecto(laberinto, yaRecorridos, camino, false, false)));

                                if (solucion[solucion.Count() - 1][0] >= 0 && solucion[solucion.Count() - 1][0] < laberinto.GetLength(0))
                                {
                                    if (solucion[solucion.Count() - 1][1] >= 0 && solucion[solucion.Count() - 1][1] < laberinto.GetLength(0))
                                    {
                                        solucion.Clear();
                                    }
                                    else
                                    {
                                        resuelto = true;
                                    }
                                }
                                else
                                {
                                    resuelto = true;
                                }
                            }
                        }
                        else
                        {
                            solucion.Add(siguiente);
                            return solucion;
                        }
                    }
                }
            }

            return solucion;
        }

        static List<int[]> Solucionlaverinto(int[,] laberinto, int[] inicio)
        {
            //variables
            List<int[]> solucion = new List<int[]>();
            Stack<int[]> camino = new Stack<int[]>();

            //matriz para comprobar los caminos que se han recorrido
            bool[,] recorridos = new bool[laberinto.GetLength(0), laberinto.GetLength(1)];

            //primer elemento
            camino.Push(inicio);
            solucion.Add(inicio);

            solucion = new List<int[]>(solucion.Concat(CaminoCorrecto(laberinto, recorridos, camino, true, false)));

            return solucion;
        }

        static void Main(string[] args)
        {
            int[,] laberinto;

            int[] inicio;

            List<int[]> solucion;

            laberinto = new int[7, 7] { { 3, 6, 3, 2, 6, 3, 6 }, { 5, 9, 12, 5, 5, 13, 5 }, { 13, 3, 6, 5, 1, 2, 12 }, { 11, 4, 5, 5, 13, 1, 10 }, { 7, 5, 13, 9, 6, 9, 6 }, { 5, 5, 3, 10, 8, 14, 5 }, { 9, 8, 12, 11, 10, 10, 12 } };
            inicio = new int[2] { 3, 0 };

            solucion = Solucionlaverinto(laberinto, inicio);
            if (solucion.Count == 1)
            {
                Console.WriteLine("El laberinto no tiene solución");
            }
            else
            {
                foreach (int[] elemento in solucion)
                {
                    Console.Write("{ ");
                    Console.Write("{0}, {1}", elemento[0], elemento[1]);
                    Console.WriteLine(" }");
                }
            }
        }
    }
}