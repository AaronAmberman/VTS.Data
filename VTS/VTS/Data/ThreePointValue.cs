namespace VTS.Data
{
    public class ThreePointValue
    {
        public float Point1 { get; set; }
        public float Point2 { get; set; }
        public float Point3 { get; set; }

        public override string ToString()
        {
            return $"({Point1},{Point2},{Point3})";
        }
    }
}
