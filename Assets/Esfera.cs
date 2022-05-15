using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfera : MonoBehaviour 
{
	public bool listo; // Crear el booleano 

	public Color[] coloresEsferas; // crear una variable para para ingresar los colores

	
	void Start ()
	{
		
	}
	
	void Update () 
	{
		// cuando se active el switch iniciar el proceso
		if (listo)
		{
			listo = false;
			StartCoroutine(CrearEsfera());
		}
	}

	private IEnumerator CrearEsfera()
	{
		//Crear de forma aleatoria las filas y las columnas en los parametros establecidos
		int columnas = Random.Range(3,14); 
		int fila = Random.Range(3,14);

		
		// Crear las secuencias para que comience a generar los parametros establecidos dentro del bucle
		for (int i = 0; i < fila; i++)
		{
			GameObject esferaAnterior = null;
			for (int j = 0; j < columnas; j++)
			{
				GameObject esferaCreada = GameObject.CreatePrimitive(PrimitiveType.Sphere); // Crear esfera
				esferaCreada.GetComponent<Transform>().position = new Vector3(j*1.5f, i*1.5f); // Asignarle posición
				int colorAzar = Random.Range(0, coloresEsferas.Length); //Buscar el indice(posicion) al azar
				var colorActual = coloresEsferas[colorAzar]; //selecciona el color en la posicion que escogio
				esferaCreada.GetComponent<MeshRenderer>().material.color = colorActual; //Asignar color a la esfera creada							
				yield return new WaitForSeconds(0.5f); //Frames en que aparece las esferas
				if(esferaAnterior != null) //verificar que no sea nulo
				{
					var colorAnterior = esferaAnterior.GetComponent<MeshRenderer>().material.color;// Selecciona el color
					if(mismoColor(colorActual,colorAnterior)) //verificar que ambos colores sean iguales, y si es verdadero color ambas en negro
					{
						esferaCreada.GetComponent<MeshRenderer>().material.color = Color.black;
						esferaAnterior.GetComponent<MeshRenderer>().material.color = Color.black;
					}
				}	
				esferaAnterior = esferaCreada; //Cambiar a la esfera anterior				
			}
		}
	}

	//Verifica si dos colores son iguales
		
	private bool mismoColor(Color primera, Color anterior)
	{
		return primera.Equals(anterior);
	}
	
}	
