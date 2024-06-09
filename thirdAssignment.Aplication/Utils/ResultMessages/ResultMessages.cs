
namespace thirdAssignment.Aplication.Utils.ResultMessages
{
    public class ResultMessages
    {
        public Dictionary<Enum, Dictionary<Enum, string>> ResultMessage { get; set; }
        public ResultMessages( string name)
        {
            ResultMessage = new(){

                {TypeOfOperation.GetAll,
                    new(){
                        {State.Success, $"Geting the {name}s was a success" },

                        { State.Error, $"Error geting the {name}s" }
                    } },


                {TypeOfOperation.GetById,
                    new(){
                        {State.Success, $" Geting the {name} was a success" },

                        {State.Error, $"Error geting the {name}" }
                    } },


                {TypeOfOperation.Save,

                    new(){
                        {State.Success, $" Saving the {name} was a success " },
                        {State.Error, $"Error saving the {name}" }
                   } },


                {TypeOfOperation.Update,
                    new(){
                        {State.Success, $"Updating the {name} was a success" },
                        {State.Error, $"Error updating the {name}" }
                    } },

                {TypeOfOperation.Delete,
                    new(){
                        {State.Success, $"Deleting the {name} was a success" },
                        {State.Error, $"Error deleting the {name}" }
                    } },

                 {TypeOfOperation.Filter,
                    new(){
                        {State.Success, $"Filtering the {name} was a success" },
                        {State.Error, $"Error filtering the {name}" }
                    } },

                };
        }


    }
}
