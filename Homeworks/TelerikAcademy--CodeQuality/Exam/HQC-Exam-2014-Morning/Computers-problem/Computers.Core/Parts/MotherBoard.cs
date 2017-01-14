namespace Computers.Core.Parts
{
    using Interfaces;

    /// <summary>
    /// The motherBoard acts as a middle man between the CPU. the RAM and the Video Card
    /// </summary>
    internal class MotherBoard : IMotherBoard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MotherBoard" /> class.
        /// </summary>
        /// <param name="cpu"> The cpu. </param>
        /// <param name="ram"> The ram. </param>
        /// <param name="videoCard"> The video card. </param>
        public MotherBoard(ICpu cpu, IRam ram, IVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.VideoCard = videoCard;
        }

        /// <summary>
        /// Gets or sets the cpu.
        /// </summary>
        /// <value> The cpu. </value>
        public ICpu Cpu { get; set; }

        /// <summary>
        /// Gets or sets the ram.
        /// </summary>
        /// <value> The ram. </value>
        public IRam Ram { get; set; }

        /// <summary>
        /// Gets or sets the video card.
        /// </summary>
        /// <value> The video card. </value>
        public IVideoCard VideoCard { get; set; }

        /// <summary>
        /// Draws the specified text.
        /// </summary>
        /// <param name="text"> The text. </param>
        public void Draw(string text)
        {
            this.VideoCard.Draw(text);
        }

        /// <summary>
        /// Gets the random number.
        /// </summary>
        /// <param name="start"> The start. </param>
        /// <param name="end"> The end. </param>
        public void GetRandomNumber(int start, int end)
        {
            this.Save(this.Cpu.GetRandomNumber(start, end));
        }

        /// <summary>
        /// Loads a value from the ram.
        /// </summary>
        /// <returns> </returns>
        public int Load()
        {
            return this.Ram.LoadValue();
        }

        /// <summary>
        /// Saves the specified number to the ram.
        /// </summary>
        /// <param name="num"> The number. </param>
        public void Save(int num)
        {
            this.Ram.SaveValue(num);
        }

        /// <summary>
        /// Squares the numberand saves it to the ram.
        /// </summary>
        /// <param name="number"> The number. </param>
        public void SquareNumber(int number)
        {
            this.Draw(this.Cpu.SquareNumber(number));
        }
    }
}