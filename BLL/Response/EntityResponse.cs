using Entity;

namespace BLL.Response
{
    public class EntityResponse<TEntity> where TEntity : BaseEntity
    {
        public bool Error { get; set; }
        public ICollection<TEntity> Entities { get; set; }
        public TEntity Entity { get; set; }
        public string Menssage { get; set; }
        public EntityResponse(string message) {
            Menssage = message;
            Error = true;
        }
        public EntityResponse(TEntity entity) {
            Entity = entity;
            Error = false;
        }
        public EntityResponse(ICollection<TEntity> entities) {
            Entities = entities;
            Error = false;
        }
    }
}
