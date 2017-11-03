using System;

namespace Bussiness.Entities {
    public class BussinessEntity {
        public int Id { get; set; }

        public override bool Equals(object value) {
            if (ReferenceEquals(null, value) || (value.GetType() != GetType())) {
                return false;
            }

            return object.ReferenceEquals(this, value) || IsEqual((BussinessEntity)value);
        }

        public bool Equals(BussinessEntity entity) {
            if (ReferenceEquals(null, entity)) {
                return false;
            }

            return ReferenceEquals(this, entity) || IsEqual(entity);
        }

        public static bool operator ==(BussinessEntity a, BussinessEntity b)
        {
            if (ReferenceEquals(a, b)) {
                return true;
            }

            return ((object) a != null) && ((object) b != null) && a.IsEqual(b);
        }

        public static bool operator !=(BussinessEntity a, BussinessEntity b) {
            return !(a == b);
        }

        private bool IsEqual(BussinessEntity entity) {
            return Id == entity.Id;
        }
    }


}
