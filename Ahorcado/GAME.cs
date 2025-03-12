using System;

public class Game
{
	private int vidas;
    private int palabra;
    private bool estado_palabra;
	private string palabra_aux;
    private string palabra_buscar;

    public Game()
	{
	this.vidas = 5;
	this.palabra = 0;
	this.estado_palabra = false;
	Palabras Lista = new Palabras();
	Console.WriteLine("Comenzo el juego");
		this.palabra_buscar = Lista.obtener_palabra(this.palabra);
	}

	public bool verificador(string word)
	{
		if (word == "")
		{
			return false;
		}
		else if(word == "HELP")
		{
			return true;
		}
		else if (word[0] >= 'A' && word[0] <= 'Z')
		{
			return true;
		}
		else { return false; }
	}

	public int vidas_restantes()
	{
		return this.vidas;
	}

	public void persona(int n)
	{
		if (n == 5)
		{
			string persona = """
				-------
				  |     |
				( _ )   |
				        |
				        |
				        |
				        |
				        |
				""";

			Console.WriteLine(persona);
		}
		else if (n == 3)
		{
			string persona = """
				-------
				  |     |
				( _ )   |
				  |--|  |
				  |     |
				  |     |
				        |
				        |
				""";
			Console.WriteLine(persona);

		}
		else if (n == 4)
		{
			string persona = """
				-------
				  |     |
				( _ )   |
				  |     |
				  |     |
				  |     |
				        |
				        |
				""";
			Console.WriteLine(persona);
		}
		else if (n == 2)
		{
			string persona = """
				-------
				   |     |
				 ( _ )   |
				|--|--|  |
				   |     |
				   |     |
				         |
				         |
				""";
			Console.WriteLine(persona);
		}
		else if (n == 1)
		{
			string persona = """
				-------
				   |     |
				 ( _ )   |
				|--|--|  |
				   |     |
				   |     |
				    \    |
				     \   |
				""";
			Console.WriteLine(persona);
		}
		else
		{
			string persona = """
				-------
				   |     |
				 ( _ )   |
				|--|--|  |
				   |     |
				   |     |
				  / \    |
				 /   \   |
				""";
			Console.WriteLine(persona);
		}
	}

	public void mostrar_palabra()
	{
        Palabras Lista = new Palabras();
		Lista.mostrar_espacios(this.palabra, this.estado_palabra);
	}

	public void proceso(string letra)
	{
        Palabras Lista = new Palabras();

		this.palabra_aux = Lista.obtener_palabra(this.palabra);
		if(letra == palabra_aux)
		{
			this.estado_palabra = true;
			Console.Write("Palabra: ");
            Lista.mostrar_espacios(this.palabra, this.estado_palabra);
            this.palabra++;
			this.estado_palabra = false;
            this.palabra_buscar = Lista.obtener_palabra(this.palabra);
			mostrar_palabra();
        }
		else
		{
			bool cambio = false;
			string aux = this.palabra_buscar;
			for(int i = 0; i < this.palabra_buscar.Length; i++)
			{
				if (this.palabra_buscar[i] == letra[0])
				{
					string l = this.palabra_buscar;
					char[] lArray = l.ToCharArray();
					lArray[i] = '-';
					this.palabra_buscar = new string(lArray);
					cambio = true;
                }
				else
				{
					continue;
				}
			}

			if (cambio == true)
			{
				int contador = 0;
                for (int i = 0; i < this.palabra_buscar.Length; i++)
				{
					if (this.palabra_buscar[i] == '-')
					{
						contador++;
					}
				}

				if(contador == this.palabra_buscar.Length)
				{
                    this.estado_palabra = true;
                    Console.Write("Palabra: ");
                    Lista.mostrar_espacios(this.palabra, this.estado_palabra);
                    this.palabra++;
                    this.estado_palabra = false;
                    mostrar_palabra();
					this.palabra_buscar = Lista.obtener_palabra(this.palabra);
                    return;
				}

                for (int i = 0; i < aux.Length; i++)
                {
                    if (aux[i] != letra[0])
                    {
						string l = aux;
                        char[] lArray = l.ToCharArray();
                        lArray[i] = '*';
                        aux = new string(lArray);
                    }
                }

				Console.Write("Letra Encontrada: ");
				for(int j = 0; j < aux.Length; j++)
				{
					Console.Write(aux[j] + " ");
				}
				Console.WriteLine();

            }
			else
			{
				this.vidas--;
			}
		}

	}

	public int obtener_palabra_aux()
	{
		return this.palabra;
	}

	public int obtener_cantidad_palabras()
	{
		Palabras list = new Palabras();
		return list.cantidad();
	}

	private class Palabras
	{
		private string[] lista = new string[9] { "LEON", "PERRO", "GATO", "ALEMANIA", "FRANCIA", "PORTUGAL", "SOL", "SATURNO", "URANO" };

		public Palabras()
		{

		}

		public void mostrar_espacios(int palabra, bool estado)
		{
			if(estado == true)
			{
				for(int i = 0; i < lista[palabra].Length; i++)
				{
					Console.Write(lista[palabra][i]);
					Console.Write(" ");
				}
				Console.WriteLine();
			}
			else
			{
				Console.Write("Cantidad de letras: ");
                for (int i = 0; i < lista[palabra].Length; i++)
                {
                    Console.Write("*");
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
		}

		public string obtener_palabra(int n)
		{
			return lista[n];
		}

		public int cantidad()
		{
			return lista.Length;
		}

    }
}