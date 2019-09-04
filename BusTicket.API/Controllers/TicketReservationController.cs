using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusTicket.API.Core.Domain;
using BusTicket.API.Persistence;
using BusTicket.API.Core;
using BusTicket.API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ServiceReference1;


namespace BusTicket.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketReservationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SendSmsSoapClient client;
        private string _passangerPhoneNumber = "";
        public TicketReservationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            client = new SendSmsSoapClient(SendSmsSoapClient.EndpointConfiguration.SendSmsSoap);
        }

        // GET: api/TicketReservation
        [HttpGet]
        public async Task<ActionResult> GetTicketReservations()
        {
            var ticketReservations = await _unitOfWork.TicketReservation.GetAll();
            return Ok(ticketReservations);

        }

        // GET: api/TicketReservation/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTicketReservation(int id)
        {
            var ticketReservation = await _unitOfWork.TicketReservation.Get(id);

            if (ticketReservation == null)
            {
                return NotFound();
            }

            return Ok(ticketReservation);
        }


        // POST: api/TicketReservation
        [HttpPost("TicketPurchase")]
        public async Task<ActionResult> PostTicketReservation(TicketReservationDTO ticketReservationDTO)
        {
            if (ticketReservationDTO == null) return BadRequest();
            TicketReservation ticketReservation = new TicketReservation();
            ticketReservation.TicketNo = ticketReservationDTO.TicketNo;
            ticketReservation.PassengerName = ticketReservationDTO.PassengerName;
            ticketReservation.PassengerPhoneNo = ticketReservationDTO.PassengerPhoneNo;
            ticketReservation.PassengerEmail = ticketReservationDTO.PassengerEmail;
            ticketReservation.Gender = ticketReservationDTO.Gender;
            ticketReservation.NoOfTicket = ticketReservationDTO.NoOfTicket;
            ticketReservation.UnitPrice = ticketReservationDTO.UnitPrice;
            ticketReservation.SeatNo = ticketReservationDTO.SeatNo;
            ticketReservation.ReservationDate = ticketReservationDTO.ReservationDate;
            ticketReservation.RouteDetailID = ticketReservationDTO.RouteDetailID;
            _unitOfWork.TicketReservation.Add(ticketReservation);
            await _unitOfWork.Complete();

            Payment payment = new Payment();
            payment.TicketResrvID = ticketReservation.TicketResrvID;
            payment.VendorName = ticketReservationDTO.VendorName;
            payment.PaymentAmount = ticketReservationDTO.PaymentAmount;
            payment.TransactionID = ticketReservationDTO.TransactionID;
            payment.PaymentDate = ticketReservationDTO.PaymentDate;
            _unitOfWork.Payment.Add(payment);
            await _unitOfWork.Complete();

            StringBuilder sb = new StringBuilder("", 200);
            _passangerPhoneNumber = ticketReservation.PassengerPhoneNo;
            sb.Append("Please Confirm Your Payment!!\n");
            sb.AppendLine("Your Ticket No: " + ticketReservation.TicketNo + "\n");
            sb.AppendLine("Your Journey Date : " + ticketReservation.ReservationDate.Date + "\n");

            sb.AppendLine("Your Seat No : " + ticketReservation.SeatNo.ToString() + "\n");
            sb.AppendLine("Thank Your for using our service\n");
            SendOneToOneSingleSms(ticketReservation.PassengerPhoneNo, sb.ToString());

            return Ok(ticketReservation);
        }

        // PUT: api/TicketReservation/5
        [HttpPut("PaymentConfirm")]
        public async Task<IActionResult> PutTicketReservation([FromBody]PaymentDTO paymentDTO)
        {
            if (paymentDTO == null) return BadRequest();
            var paymentModel = _mapper.Map<Payment>(paymentDTO);
            _unitOfWork.Payment.Update(paymentModel);
            int count = await _unitOfWork.Complete();
            if (count > 1)
            {
                StringBuilder sb = new StringBuilder("", 200);
                sb.Append("Your Payment is Confirm !!\n");

                SendOneToOneSingleSms(_passangerPhoneNumber, sb.ToString());
            }
            return Ok(paymentDTO);
        }

        // DELETE: api/TicketReservation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketReservation>> DeleteTicketReservation(int id)
        {
            var ticketReservation = await _unitOfWork.TicketReservation.Get(id);
            if (ticketReservation == null) return BadRequest();
            _unitOfWork.TicketReservation.Remove(ticketReservation);
            await _unitOfWork.Complete();
            return Ok(ticketReservation);
        }

        void SendOneToOneSingleSms(string number, string text)
        {
            try
            {
                client.OneToOneAsync("01711432258", "Rashed$1245492$", number, text, "OneToOne", "Reminder",
                    "Ticket Purchase");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
