﻿namespace ReservationSystemAPI.Models.Response
{
    public class Respuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            Exito = 0;
        }
    }
}
