namespace common {
  public class ObjectExtensions {
        public static int ToInt(this object source)
        {
            int n;
            int.TryParse(source+"", out n);
            return n;
        }
}
