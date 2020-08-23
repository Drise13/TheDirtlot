namespace Assets.Utils
{
    public static class Utils
    {
        public static T As<T>(this object o)
        {
            return (T)o;
        }
    }
}