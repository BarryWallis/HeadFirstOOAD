using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DougsDogDoors.Model
{
    public class Bark : IEquatable<Bark>
    {
        string trainedBark;

        public Bark(string trainedBark)
        {
            if (string.IsNullOrWhiteSpace(trainedBark))
                throw new ArgumentNullException(nameof(trainedBark));

            this.trainedBark = trainedBark;
        }

        public bool Equals(Bark other) => other != null && trainedBark == other.trainedBark;

        public override bool Equals(object obj)
        {
            Bark other = obj as Bark;
            return Equals(other);
        }

        public override int GetHashCode() => trainedBark.GetHashCode();

        public static bool operator ==(Bark bark1, Bark bark2)
            => bark1 is null || bark2 is null ?
                Object.Equals(bark1, bark2)
                : bark1.Equals(bark2);


        public static bool operator !=(Bark bark1, Bark bark2)
            => !(bark1 is null || bark2 is null ?
                Object.Equals(bark1, bark2)
                : bark1.Equals(bark2));

        public bool IsThisTheDog(string checkBark) => trainedBark == checkBark;

        public override string ToString() => trainedBark;
    }
}
