using AutoMapper;
using FluentValidation;
using Safe_Development.BusinessLayer.DTOs;
using Safe_Development.BusinessLayer.Interfaces;
using Safe_Development.BusinessLayer.Validation;
using Safe_Development.DataLayer.Interfaces;
using Safe_Development.DataLayer.Models;

namespace Safe_Development.BusinessLayer.Services
{
    public class DebitCardService : IDebitCardService
    {
        private IDebitCardRepository _repository;
        private IValidator<DebitCardDTO> _validator;
        private IMapper _mapper;

        public DebitCardService(IDebitCardRepository repository, IValidator<DebitCardDTO> validator, IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IList<DebitCardDTO>> GetCards()
        {
            var debitCards = await _repository.GetCards();
            List<DebitCardDTO> debitCardsDTOList = _mapper.Map<List<DebitCardDTO>>(debitCards);
            return debitCardsDTOList;
        }

        public async Task<IOperationResult<DebitCardDTO>> GetDebitCardById(int id)
        {
            var debitCardGot = await _repository.GetDebitCardById(id);
            var debitCardDTO = _mapper.Map<DebitCardDTO>(debitCardGot);
            var check = await _validator.ValidateAsync(debitCardDTO);
            if (!check.IsValid)
            {
                var failures = check.Errors.Select(e => new OperationFailure
                {
                    PropertyName = e.PropertyName,
                    Code = e.ErrorCode,
                    Message = e.ErrorMessage
                }).ToArray();
                return new OperationResult<DebitCardDTO>(failures);
            }
            else
            {
                return new OperationResult<DebitCardDTO>(debitCardDTO);
            }
        }

        public async Task<IOperationResult<DebitCardDTO>> CreateDebitCard(DebitCardDTO debitCardDTO)
        {
            var check = await _validator.ValidateAsync(debitCardDTO);
            if (!check.IsValid)
            {
                var failures = check.Errors.Select(e => new OperationFailure
                {
                    PropertyName = e.PropertyName,
                    Code = e.ErrorCode,
                    Message = e.ErrorMessage
                }).ToArray();
                return new OperationResult<DebitCardDTO>(failures);
            }
            else
            {
                var debitCardToRegister = _mapper.Map<DebitCard>(debitCardDTO);
                await _repository.CreateDebitCard(debitCardToRegister);
                return new OperationResult<DebitCardDTO>(debitCardDTO);
            }
        }

        public async Task Update(int id, string name)
        {
            var debitCardToUpdate = await _repository.GetDebitCardById(id);
            await _repository.Update(id, debitCardToUpdate.Name);
        }
    }
}
