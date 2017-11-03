using System;
using Bussiness.Entities;
using Bussiness.Logic;

namespace UI.Console {
    class Users {
        public UserLogic UserLogic { get; set; }

        public Users() {
            UserLogic = new UserLogic();
        }

        public void Menu() {
            string option;
            do {
                System.Console.WriteLine("Bienvenido");
                System.Console.WriteLine("1– Listado General");
                System.Console.WriteLine("2– Consulta");
                System.Console.WriteLine("3– Agregar");
                System.Console.WriteLine("4- Modificar");
                System.Console.WriteLine("5- Eliminar");
                System.Console.WriteLine("6- Salir");
                option = System.Console.ReadLine();
                switch (option) {
                    case "1":
                        GeneralList();
                        break;
                    case "2":
                        Consult();
                        break;
                    case "3":
                        Add();
                        break;
                    case "4":
                        Modify();
                        break;
                    case "5":
                        Delete();
                        break;
                    default:
                        System.Console.Clear();
                        System.Console.WriteLine("Opción incorrecta");
                        break;
                }
            } while (option != "6");

        }

        private void Delete() {
            throw new NotImplementedException();
        }

        private void Modify() {
            throw new NotImplementedException();
        }

        private void GeneralList() {
            foreach (User usr in UserLogic.GetAll()) {
                ShowData(usr);
            }
        }

        private void ShowData(User usr) {
            System.Console.WriteLine("Usuario: {usr.Id}");
            System.Console.WriteLine("\t\tNombre: {usr.Name}");
            System.Console.WriteLine("\t\tApellido: {usr.LastName}");
            System.Console.WriteLine("\t\tNombre de usuario: {usr.Username}");
            System.Console.WriteLine("\t\tClave: {usr.Password}");
            System.Console.WriteLine("\t\tEmail: {usr.EMail}");
            System.Console.WriteLine("\t\tHabilitado: {usr.Enable}");
            System.Console.WriteLine("");
        }

        private void Add() {
            throw new NotImplementedException();
        }

        private void Consult() {
            System.Console.Clear();
            System.Console.Write("Ingrese un ID del usuario: ");
            int id = int.Parse(System.Console.ReadLine());
        }
    }
}
