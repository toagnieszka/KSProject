﻿namespace KSProject.Patterns.Mapper
{
	public interface IMapper<in Input, out Output> where Input : class where Output : class
	{
		public Output Map(Input input);
	}
}
