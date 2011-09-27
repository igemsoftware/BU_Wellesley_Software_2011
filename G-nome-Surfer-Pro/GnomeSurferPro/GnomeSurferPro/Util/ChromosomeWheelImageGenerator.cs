using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GnomeSurferPro.Util
{
    //Helper class for grabbing a .png of the current chromosome in Prokaryotic searches
    class ChromosomeWheelImageGenerator
    {

        private String _chromosome_accession_code;

        public ChromosomeWheelImageGenerator(String chromosome_accession_code)
        {
            _chromosome_accession_code = chromosome_accession_code;
        }

        public String getWheelImageSource()
        {
            return @"..\Resources\wheel_images\" + _chromosome_accession_code + ".png";
        }

    }
}
