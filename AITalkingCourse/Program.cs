using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;

var endpoint = new Uri("https://ai-gguivisdalsky0381ai865657206322.services.ai.azure.com");
var key = new AzureKeyCredential("Eh49dpqAQfq6x2txKZ1OPg2HdQ23x8kFoSeSkyARuHy0OI5ayhGSJQQJ99BCACHYHv6XJ3w3AAAAACOGVfim");
AzureOpenAIClient client = new AzureOpenAIClient(endpoint,key);
var messages = new List<ChatMessage>();
messages.Add(new SystemChatMessage("Sos un asistente de cocina, quiero que me ofrezcas un plato a realizar con su receta con los ingredientes que te de a continuacion. Primero saluda a Cynthia diciendole hola Cyn, que tal tu dia con Juli y Mica?"));
ChatClient chatClient = client.GetChatClient("AzureOpenAiCourse");

var chatCompletion = await chatClient.CompleteChatAsync(messages);
string response = chatCompletion.Value.Content[0].Text;

Console.WriteLine(response);

var request = Console.ReadLine();
messages.Add(new UserChatMessage(request));
chatCompletion = await chatClient.CompleteChatAsync(messages);

response = chatCompletion.Value.Content[0].Text;
Console.WriteLine(response);
