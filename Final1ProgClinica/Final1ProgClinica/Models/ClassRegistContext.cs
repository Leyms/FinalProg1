using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Final1ProgClinica.Models
{
    public class ClassRegistContext:DbContext
    {
        public ClassRegistContext()
            : base("CadenaRegClinica")
        { }
        public DbSet<ClassPacientes>Pacientes  { get; set; }
        public DbSet<ClassMedicos>Medicos  { get; set; }
        public DbSet<ClassHabitaciones>Habitaciones  { get; set; }
        public DbSet<ClassIngresos>Ingresos  { get; set; }
        public DbSet<ClassCitas>Citas  { get; set; }
        public DbSet<ClassAltas>Altas  { get; set; }

    }
}