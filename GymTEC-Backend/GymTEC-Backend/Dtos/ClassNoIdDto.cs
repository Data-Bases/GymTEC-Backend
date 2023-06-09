﻿using Nest;

namespace GymTEC_Backend.Dtos
{
    public class ClassNoIdDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public bool IsGrupal { get; set; }
        public int EmployeeId { get; set; }
        public int IdServices { get; set; }
        public string BranchName { get; set; }
    }
}
