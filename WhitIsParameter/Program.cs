using System;
namespace WhitIsParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Description desc = new Description();
            //int num1 = 10;
            //int num2 = 20;
            ////값 형식 전달임 (함수안에서는 실행되지만 함수밖으로 나오면 안바뀜)
            //desc.ValueTypeParam(num1, num2); 
            //Console.WriteLine("first: {0}, second: {1}", num1, num2);
            ////값 형식 전달임 (함수안에서는 실행되지만 함수밖으로 나오면 안바뀜)

            ////참조 형식 전달임 (원본변수를 수정할 수 있음 원본변수의 주소를 넘겨주는 방식임)
            //desc.RefTypeParam(ref num1, ref num2);
            //Console.WriteLine("first: {0}, second: {1}", num1, num2); //함수실행후 메인에서도 바뀌어서 나옴
            ////참조 형식 전달임

            ////반환형 형식 전달임 (아무값도 없는 변수를 함수에 대입하면 함수안에서 변수를 초기화해서 반환됨)
            //int number;
            //desc.OutTypeParam(out number);
            //Console.WriteLine("[main] number: {0}", number);
            ////int.TryParse 방식이 바로 반환형 형식 전달임
            ////반환형 형식 전달임

            //가변형 형식 전달임 (입력값을 가변적으로 넣을 수 있음)
            //Console.WriteLine() 함수가 대표적인 가변형 형식 전달방식임
            desc.FlexibleTypeParam(1, 2, 3, 10, 40 ,100, 101,105); //변수를 몇개 넣든 상관없음
            desc.ArrayParam(new int[] { 1, 2, 3, 5 }); //params 키워드를 안쓰고 입력을받으면 이런식으로 해야됨
            int[] numbers = { 1, 4, 3 };
            desc.ArrayParam(numbers); //배열을 이미 만들어놨으면 굳이 params를 쓰지않아도 됨
            //가변형 형식 전달임
        } //Main
    }
}