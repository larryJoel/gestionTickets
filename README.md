# gestionTickets
Aplicación para la gestión de tickets hecha en windows form c#
###Importante:
Se debe crear un directorio llamado: "Json Sample", donde estarn los archivos JSON y elk archivo de texto para generar el ticket impreso
El JSON Usuario.json tiene esta estructura:
[
  {
    "Id": "1",
    "Nombre": "XXXXX",
    "Apellido": "XXXXXX",
    "Dni": "9898989898989",
    "Cargo": "analista",
    "Email": "yo@gmail",
    "Usuario": "analista",
    "Sector": "sistemas",
    "Password": "123",
    "nivelAcceso": "supervisor"
  }
]
El JSON Ticket.json tiene esta estructura:
[
{
    "Id": "1",
    "NroTicket": "0KIH0ADDI",
    "Cliente": "Juan Perez medina",
    "EmailCliente": "juan@gmail.com",
    "Incidencia": "no puedo entrar al sistema administrativo lorem impsum dasdnpnpoanpoajd, nodadoasndp asdnosadn pasondpaon",
    "Usuario": "analista 3",
    "Fecha": "lunes, 31 de octubre de 2022",
    "TipoIncidencia": "software-aplicación interna",
    "Prioridad": "Alta",
    "Estado": "Pendiente",
    "Solucion": "En proceso",
    "Observaciones": "Buscando la forma de agregar comentarios a ver si funciona"
  }
]
El JSON Seguimiento.json tiene esta estructura:
[
 {
    "Id": "1",
    "NroTicket": "0KIH0ADDI",
    "Estado": "Abierto",
    "Usuario": "CCKCKJCKJKC",
    "Fecha": "23/05/2022",
    "Mensaje": "Prueba de seguimiento"
  }
]
