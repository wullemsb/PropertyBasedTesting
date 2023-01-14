namespace PropertyBasedTesting
{
    public class WhenIAddTwoNumbers
    {

        int Add(int x, int y) => x + y;

        [Property(Verbose = true)]
        public void TheResultShouldNotDependOnTheOrderOfTheParameters(int number1, int number2)
        {
            var result1 = Add(number1, number2);
            var result2 = Add(number2, number1);

            Assert.Equal(result1, result2);
        }

        [Property]
        public void TheOrderOfTheOperationsDoesNotMatter(int number1, int number2, int number3)
        {
            var result1 = Add(Add(number1, number2), number3);
            var result2 = Add(number1, Add(number2, number3));

            Assert.Equal(result1, result2);
        }

        [Property]
        public void AddingZeroIsTheSameAsDoingNothing(int number1)
        {
            var result1 = Add(number1, 0);
            var result2 = number1;

            Assert.Equal(result1, result2);
        }
    }
}