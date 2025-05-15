using System.Text.Json;

var engine = new Jint.Engine();
engine.SetValue(
	"log",
	(string prefix, object? obj) => Console.WriteLine($"{prefix, 40}: {JsonSerializer.Serialize(obj)}")
);
engine.SetValue("csEvaluate", (Func<object> f) => f());
engine.Evaluate(
	"""
	const counter = () => { let i = 0; return () => i++; };

  log('csEvaluate counter', csEvaluate(counter()));
  log('csEvaluate counter again', csEvaluate(counter()));
"""
);
