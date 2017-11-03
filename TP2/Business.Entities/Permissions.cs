using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Bussiness.Entities {
    public class Permissions : BussinessEntity {
        public String Name { get; set; }

        public static long FromPrivilegesToInt(List<Privileges> privileges) {
            return privileges.Sum(p => (long)p);
        }

        public static List<Privileges> FromIntToPrivileges(long privilege) {
            List<Privileges> privileges = new List<Privileges>();

            foreach (Privileges p in Enum.GetValues(typeof(Privileges))) {
                if ((privilege & (long)p) != 0) {
                    privileges.Add(p);
                }
            }
            return privileges;
        }
    }

    [Flags]
    public enum Privileges {
        None = 0,

        CanCreateUsers = 1 << 0,
        CanReadUsers = 1 << 1,
        CanUpdateUsers = 1 << 2,
        CanDeleteUsers = 1 << 3,
        AnyUser = CanCreateUsers | CanReadUsers | CanUpdateUsers | CanDeleteUsers,

        CanCreatePersons = 1 << 4,
        CanReadPersons = 1 << 5,
        CanUpdatePersons = 1 << 6,
        CanDeletePersons = 1 << 7,
        AnyPerson = CanCreatePersons | CanReadPersons | CanUpdatePersons | CanDeletePersons,

        CanCreatePlans = 1 << 8,
        CanReadPlans = 1 << 9,
        CanUpdatePlans = 1 << 10,
        CanDeletePlans = 1 << 11,
        AnyPlan = CanCreatePlans | CanReadPlans | CanUpdatePlans | CanDeletePlans,

        CanCreateSubjects = 1 << 12,
        CanReadSubjects = 1 << 13,
        CanUpdateSubjects = 1 << 14,
        CanDeleteSubjects = 1 << 15,
        AnySubject = CanCreateSubjects | CanReadSubjects | CanUpdateSubjects | CanDeleteSubjects,

        CanCreateCommissions = 1 << 16,
        CanReadCommissions = 1 << 17,
        CanUpdateCommissions = 1 << 18,
        CanDeleteCommissions = 1 << 19,
        AnyCommission = CanCreateCommissions | CanReadCommissions | CanUpdateCommissions | CanDeleteCommissions,

        CanCreateCourses = 1 << 20,
        CanReadCourses = 1 << 21,
        CanUpdateCourses = 1 << 22,
        CanDeleteCourses = 1 << 23,
        AnyCourse = CanCreateCourses | CanReadCourses | CanUpdateCourses | CanDeleteCourses,

        CanCreateInscriptions = 1 << 24,
        CanReadInscriptions = 1 << 25,
        CanDeleteInscriptions = 1 << 26,
        AnyInscription = CanCreateInscriptions | CanReadInscriptions | CanDeleteInscriptions,

        CanCreateSpecialties = 1 << 27,
        CanReadSpecialties = 1 << 28,
        CanUpdateSpecialties = 1 << 29,
        CanDeleteSpecialties = 1 << 30,
        AnySpecialty = CanCreateSpecialties | CanReadSpecialties | CanUpdateSpecialties | CanDeleteSpecialties
    }
}
