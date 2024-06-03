using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace EjercicioClase3Modulo2EFCore
{
    internal class Program
    {
        static void Main( string[] args )
        {

            var option = new DbContextOptionsBuilder<BDContext>();
            option.UseSqlServer("Data Source=localhost;Initial Catalog=SimpleIMDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            var context = new BDContext(option.Options);
           
            
            #region Pasos previos
            //Ejecutar el script de base de datos en Management Studio para crear la base de datos y la tabla con datos
            //Instalar Microsoft.EntityFrameworkCore y Microsoft.EntityFrameworkCore.SqlServer
            //Crear las entidades necesarias
            //Crear el dbcontext
            //Configurar aqui el connection string e instanciar el contexto de la base de datos.
            #endregion

            #region ejercicio 1
            //Obtener un listado de todos los actores y actrices de la tabla actor
            var result = context.actor.ToList();
            #endregion

            #region ejercicio 2
            //Obtener listado de todas las actrices de la tabla actor
            var actrices = context.actor.Where(actor => actor.Genero == "F").ToList();
            #endregion
            
            #region ejercicio 3
            //Obtener un listado de todos los actores y actrices mayores de 50 años de la tabla actor

            var mayores = context.actor.Where(actor => actor.Edad > 50).ToList();
            #endregion
            //Console.ReadKey();
            #region ejercicio 4
            //Obtener la edad de la actriz "Julia Roberts"

            var edad_julia = context.actor.Where(actor => actor.Nombre == "Julia" && actor.Apellido== "Roberts").Select(p => p.Edad).ToList();

            

            #endregion

            #region ejercicio 5
            //Insertar un nuevo actor en la tabla actor con los siguientes datos:
            //nombre: Ricardo
            //apellido: Darin
            //edad: 67 años
            //nombre_artistico: Ricardo Darin
            //nacionalidad: argentino
            //género: Masculino.

            Actor nuevoActor = new Actor() {Nombre = "Ricardo", Apellido = "Darin", Edad = 67, Nombre_artistico = "Ricardo Darin", Nacionalidad = "argentino", Genero = "M" };
            context.actor.Add(nuevoActor);
            context.SaveChanges();
            #endregion

            #region ejercicio 6
            //obtener la cantidad de actores y actrices que no son de Estados Unidos.
            var actores_not_usa = context.actor.Where(actor => actor.Nacionalidad != "USA").Count();
            //Console.ReadKey();
            #endregion

            #region ejercicio 7
            //obtener los nombres y apellidos de todos los actores maculinos.
            #endregion

            var nom_ape_masculinos = context.actor.Where(actor => actor.Genero == "M").Select(pm => new {pm.Nombre,pm.Apellido}).ToList(); 

            //Console.ReadKey();


        }
    }
}