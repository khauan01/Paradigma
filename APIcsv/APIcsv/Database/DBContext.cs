using APIcsv.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace APIcsv.Database
{
    public class DBContext
    {
        private const string PathNome = @"C:\1 -Faculdade\API Quarta\APIcsv\APIcsv\animais.txt";

        // Declaração da lista privada para armazenar os animais
        private readonly List<Animal> _animais = new List<Animal>();

        public DBContext()
        {
            if (!File.Exists(PathNome))
                throw new FileNotFoundException($"Arquivo não encontrado: {PathNome}");

            string[] lines = File.ReadAllLines(PathNome);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] coluns = lines[i].Split(';');

                Animal animal = new();
                animal.Id = int.Parse(coluns[0]);
                animal.Name = coluns[1];
                animal.Classification = coluns[2];
                animal.Origin = coluns[3];
                animal.Reproduction = coluns[4];
                animal.Freeding = coluns[5];

                _animais.Add(animal);
            }
        }

        // Propriedade pública para acessar a lista de animais
        public List<Animal> Animais => _animais;
    }
}
