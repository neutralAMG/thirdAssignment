
using AutoMapper;
using thirdAssignment.Aplication.Utils.ResultMessages;


namespace thirdAssignment.Aplication.Core
{
    public class BaseService<TSaveDto, TViewModel, TEntity> : IBaseService<TSaveDto,  TViewModel, TEntity>

        where TSaveDto : class
   
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
            catch 
            {

                result.IsSuccess = false;
                result.Message = _resultMessages.ResultMessage[TypeOfOperation.GetById][State.Error];
                return result;
                throw;
            }
        }

        public virtual async Task<Result<TSaveDto>> Save(TSaveDto saveDto)
        {
            Result<TSaveDto> result = new();
            try
            {
                if (saveDto is null)
                {
                    result.IsSuccess = false;
                    result.Message = _resultMessages.ResultMessage[TypeOfOperation.Save][State.Error];
                    return result;
                }

                TEntity EntityToSave = _mapper.Map<TEntity>(saveDto);

                TEntity SavedEntity = await _baseRepository.Save(EntityToSave);

                if (SavedEntity is null)
                {
                    result.IsSuccess = false;
                    result.Message = _resultMessages.ResultMessage[TypeOfOperation.Save][State.Error];
                    return result;
                }

                result.Data = _mapper.Map<TSaveDto>(SavedEntity);

                result.Message = _resultMessages.ResultMessage[TypeOfOperation.Save][State.Success];
                return result;
            }
            catch 
            {
                result.IsSuccess = false;
                result.Message = _resultMessages.ResultMessage[TypeOfOperation.Save][State.Error];
                return result;
                throw;
            }
        }

        public virtual async Task<Result<TSaveDto>> Update(TSaveDto UpdateDto)
        {
            Result<TSaveDto> result = new();
            try
            {
                if (UpdateDto is null)
                {
                    result.IsSuccess = false;
                    result.Message = _resultMessages.ResultMessage[TypeOfOperation.Update][State.Error];
                    return result;
                }
                TEntity EntityToUpdate = _mapper.Map<TEntity>(UpdateDto);

               

                TEntity UpdatedEntity = await _baseRepository.Update(EntityToUpdate);

                if (UpdatedEntity is null)
                {
                    result.IsSuccess = false;
                    result.Message = _resultMessages.ResultMessage[TypeOfOperation.Update][State.Error];
                    return result;
                }
                result.Data = _mapper.Map<TSaveDto>(UpdatedEntity);

                result.Message = _resultMessages.ResultMessage[TypeOfOperation.Update][State.Success];
                return result;
            }
            catch 
            {
                result.IsSuccess = false;
                result.Message = _resultMessages.ResultMessage[TypeOfOperation.Update][State.Error];
                return result;
                throw;
            }
        }
        public virtual async Task<Result<TViewModel>> Delete(Guid id)
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
            catch 
            {
                result.IsSuccess = false;
                result.Message = _resultMessages.ResultMessage[TypeOfOperation.Delete][State.Error];
                return result;
                throw;
            }
        }


    }
}
