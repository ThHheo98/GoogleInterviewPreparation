using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test58
    {
        [TestCase]
        public void Test(byte[] screen, int width, int x1, int x2, int y)
        {
            int start_offset = x1%8;
            int first_full_byte = x1/8;
            if (start_offset != 0)
            {
                first_full_byte++;
            }

            int end_offset = x2%8;
            int last_full_byte = x2/8;
            if (end_offset != 7)
            {
                last_full_byte--;
            }

            // set full byte
            for (int i = first_full_byte; i <= last_full_byte; i++)
            {
                screen[(width/8)*y + i] = 0xff;
            }

            // create mask for begin and end of string
            var start_mask = (byte) (0xff >> start_offset);
            var end_mask = (byte) (0xff >> (end_offset + 1));

            if ((x1/8) == (x2/8))
            {
                var mask = (byte) (start_mask & end_mask);
                screen[(width/8)*y + first_full_byte - 1] |= mask;
            }
            else
            {
                if (start_offset != 0)
                {
                    int byte_number = (width/8)*y + first_full_byte - 1;
                    screen[byte_number] |= start_mask;
                }
            }

            if (end_offset != 7)
            {
                int byte_number = (width/8)*y + last_full_byte + 1;
                screen[byte_number] |= end_mask;
            }
        }
    }
}