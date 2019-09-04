using BusTicket.WebAPI.Core;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusTicket.WebAPI.com.onnorokomsms.api2;


namespace BusTicket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TicketReservationController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TicketReservationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }


        // GET: api/TicketReservation
        [HttpGet]
        public async Task<IHttpActionResult> GetTicketReservations()
        {
            var ticketReservations = await _unitOfWork.TicketReservation.GetAll();
            return Ok(ticketReservations);
            
        }

        // GET: api/TicketReservation/5
        [HttpGet,Route("{id}")]
        public async Task<IHttpActionResult> GetTicketReservation(int id)
        {
            var ticketReservation = await _unitOfWork.TicketReservation.Get(id);

            if (ticketReservation == null)
            {
                return NotFound();
            }

            return Ok(ticketReservation);
        }


        // POST: api/TicketReservation
        [HttpPost]
        public async Task<IHttpActionResult> PostTicketReservation(TicketReservationDTO ticketReservationDTO)
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

            SendOneToOneSingleSms(ticketReservation.PassengerPhoneNo, "Success");


            return Ok(ticketReservation);
        }

        // PUT: api/TicketReservation/5
        [HttpPut]
        public async Task<IHttpActionResult> PutTicketReservation(TicketReservation ticketReservation)
        {
            if (ticketReservation == null) return BadRequest();
            _unitOfWork.TicketReservation.Update(ticketReservation);
            await _unitOfWork.Complete();
            return Ok(ticketReservation);
        }



        // PUT: api/TicketReservation/5
        [HttpPut, Route("PaymentConfirm")]
        public async Task<IHttpActionResult> PutTicketReservation([FromBody] PaymentDTO paymentDTO)
        {
            if (paymentDTO == null) return BadRequest();
            var paymentModel = _mapper.Map<Payment>(paymentDTO);
            _unitOfWork.Payment.Update(paymentModel);
            await _unitOfWork.Complete();
            return Ok(paymentDTO);
        }

        // DELETE: api/TicketReservation/5
        [HttpDelete,Route("{id}")]
        public async Task<IHttpActionResult> DeleteTicketReservation(int id)
        {
            var ticketReservation = await _unitOfWork.TicketReservation.Get(id);
            if (ticketReservation == null) return BadRequest();
            _unitOfWork.TicketReservation.Remove(ticketReservation);
            await _unitOfWork.Complete();
            return Ok(ticketReservation);
        }

        void SendOneToOneSingleSms(string mobileno, string text)
        {
            try
            {
                var sms = new SendSms();
                string returnValue = sms.OneToOne("01711432258", "Rashed$1245492$", mobileno, text,
                    "OneToOne", "Reminder", "Purchase Ticket");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
