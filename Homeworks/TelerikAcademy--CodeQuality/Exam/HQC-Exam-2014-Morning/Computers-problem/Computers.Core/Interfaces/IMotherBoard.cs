namespace Computers.Core.Interfaces
{
    /// <summary>
    /// The motherBoard acts as a middle man between the CPU. the RAM and the Video Card
    /// </summary>
    public interface IMotherBoard
    {
        /// <summary>
        /// Gets or sets the cpu.
        /// </summary>
        /// <value> The cpu. </value>
        ICpu Cpu { get; set; }

        /// <summary>
        /// Gets or sets the ram.
        /// </summary>
        /// <value> The ram. </value>
        IRam Ram { get; set; }

        /// <summary>
        /// Gets or sets the video card.
        /// </summary>
        /// <value> The video card. </value>
        IVideoCard VideoCard { get; set; }

        /// <summary>
        /// Draws the specified text.
        /// </summary>
        /// <param name="text"> The text. </param>
        void Draw(string text);

        /// <summary>
        /// Gets the random number.
        /// </summary>
        /// <param name="start"> The start. </param>
        /// <param name="end"> The end. </param>
        void GetRandomNumber(int start, int end);

        /// <summary>
        /// Loads a value from the ram.
        /// </summary>
        /// <returns> </returns>
        int Load();

        /// <summary>
        /// Saves the specified number to the ram.
        /// </summary>
        /// <param name="num"> The number. </param>
        void Save(int num);

        /// <summary>
        /// Squares the numberand saves it to the ram.
        /// </summary>
        /// <param name="number"> The number. </param>
        void SquareNumber(int number);
    }
}