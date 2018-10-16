using System;

namespace PhotoGallaryMVC.Models {

    public class Picture : IEquatable<Picture> {

        public string Url { get; set; }
        public string FullPath { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string DateDownload { get; set; }
        public string Resolution { get; set; }

        public bool Equals(Picture other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Url, other.Url) 
                   && string.Equals(FullPath, other.FullPath)
                   && string.Equals(Name, other.Name)
                   && string.Equals(Size, other.Size)
                   && string.Equals(DateDownload, other.DateDownload)
                   && string.Equals(Resolution, other.Resolution);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Picture)obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Url != null ? Url.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (FullPath != null ? FullPath.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Size != null ? Size.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DateDownload != null ? DateDownload.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Resolution != null ? Resolution.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Picture left, Picture right) => Equals(left, right);

        public static bool operator !=(Picture left, Picture right) => !Equals(left, right);
    }
}