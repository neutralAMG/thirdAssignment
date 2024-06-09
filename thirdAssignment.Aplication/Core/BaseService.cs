
using AutoMapper;
using thirdAssignment.Aplication.Interfaces;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Aplication.Utils.ResultMessages;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Core
{
    public class BaseService<TSaveDto, TUpdateDto, TViewModel, TEntity> : IBaseService<TSaveDto, TUpdateDto, TViewModel, TEntity>

        where TSaveDto : class
        where TUpdateDto : class
        where TViewModel : class
        where TEntity : class
    {

        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;
        private readonly ResultMessages _resultMessages;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper, ResultMessages resultMessages)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _resultMessages = resultMessages;
        }



        //public async Task<Result<List<TViewModel>>> GetAll(Guid id)
        //{
        //    Result<List<TViewModel>> result = new();
        //    try
        //    {
        //        List<TEntity> usersGetted = await _baseRepository.GetAll(id);

        //        result.Data = _mapper.Map<List<TViewModel>>(usersGetted);
        //        result.Message = _resultMessages.ResultMessage[TypeOfOperation.GetAll][State.Success];

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = _resultMessages.ResultMessage[TypeOfOperation.GetAll][State.Error];
        //        return result;
        //        throw;
        //    }
        //}

        public virtual async Task<Result<TViewModel>> GetById(Guid id)
        {
            Result<TViewModel> result = new();
            try
            {
                TEntity EntityGeted = await _baseRepository.GetById(id);

                if (EntityGeted is null)
                {
                    result.IsSuccess = false;
                    result.Message = _resultMessages.ResultMessage[TypeOfOperation.GetById][State.Error];
                    return result;
                }

                result.Data = _mapper.Map<TViewModel>(EntityGeted);

                result.Message = _resultMessages.ResultMessage[TypeOfOperation.GetById][State.Success];
                return result;
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = _resultMessages.ResultMessage[TypeOfOperation.GetById][State.Error];
                return result;
                throw;
            }
        }

        public async Task<Result<TViewModel>> Save(TSaveDto saveDto)
        {
            Result<TViewModel> result = new();
            try
            {
                if (saveDto is null)
                {
                    result.IsSuccess = false;
                    result.Message = _resultMessages.ResultMessage[TypeOfOperation.Save][State.Error];
                    return result;
                }

                TEntity SavedEntity = _mapper.Map<TEntity>(saveDto);

                await _baseRepository.Save(SavedEntity);


                result.Message = _resultMessages.ResultMessage[TypeOfOperation.Save][State.Success];
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = _resultMessages.ResultMessage[TypeOfOperation.Save][State.Error];
                return result;
                throw;
            }
        }

        public async Task<Result<TViewModel>> Update(TUpdateDto UpdateDto)
        {
            Result<TViewModel> result = new();
            try
            {
                if (UpdateDto is null)
                {
                    result.IsSuccess = false;
                    result.Message = _resultMessages.ResultMessage[TypeOfOperation.Update][State.Error];
                    return result;
                }
                TEntity UpdatedEntity = _mapper.Map<TEntity>(UpdateDto);
                await _baseRepository.Update(UpdatedEntity);

                result.Message = _resultMessages.ResultMessage[TypeOfOperation.Update][State.Success];
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = _resultMessages.ResultMessage[TypeOfOperation.Update][State.Error];
                return result;
                throw;
            }
        }
        public async Task<Result<TViewModel>> Delete(Guid id)
        {
            Result<TViewModel> result = new();
            try
            {
                TEntity EntityDeleted = await _baseRepository.GetById(id);

                if (EntityDeleted is null)
                {
                    result.IsSuccess = false;
                    result.Message = _resultMessages.ResultMessage[TypeOfOperation.Delete][State.Error];
                    return result;
                }

                await _baseRepository.Delete(EntityDeleted);


                result.Message = _resultMessages.ResultMessage[TypeOfOperation.Delete][State.Success];
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = _resultMessages.ResultMessage[TypeOfOperation.Delete][State.Error];
                return result;
                throw;
            }
        }


    }
}
