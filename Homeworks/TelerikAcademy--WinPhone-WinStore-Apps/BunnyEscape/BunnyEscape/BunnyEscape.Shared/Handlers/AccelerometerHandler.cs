using System;
using System.Collections.Generic;
using System.Text;
using Windows.Devices.Sensors;
using Windows.Foundation;

namespace BunnyEscape.Handlers
{
    public class TurboModeInputHandler
    {
        private Accelerometer accl;
        private Gyrometer gyros;

        private double jumpBonus;
        private double walkLeftBonus;
        private double walkRightBonus;

        public TurboModeInputHandler()
        {
            accl = Accelerometer.GetDefault();
            if (null != accl)
            {
                accl.ReadingChanged += OnAcclReadingsChanged;
            }

            gyros = Gyrometer.GetDefault();
            if (null != gyros)
            {
                gyros.ReadingChanged += OnGyrosReadingsChanged;
            }

        }

        private void OnGyrosReadingsChanged(Gyrometer sender, GyrometerReadingChangedEventArgs args)
        {
            var x = args.Reading.AngularVelocityX;
            this.walkLeftBonus = -x;
            this.walkRightBonus = x;
        }

        private void OnAcclReadingsChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            var y = args.Reading.AccelerationX;
            var z = args.Reading.AccelerationZ;
            jumpBonus = z * y;

            if (jumpBonus < 0)
            {
                jumpBonus = 0;
            }
        }

        public double WalkLeftMultyplyer
        {
            get
            {
                return walkLeftBonus + 1;
            }
        }

        public double WalkRightMultyplyer
        {
            get
            {
                return walkRightBonus + 1;
            }
        }

        public double JumpMultyplyer
        {
            get
            {
                return jumpBonus + 1;
            }
        }
    }
}
