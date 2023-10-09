using MagicBalanceConfigurator.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MagicBalanceConfigurator
{
    public class MessageBoxLocalizer
    {
        Dictionary<string, string> EngMessages = new Dictionary<string, string>();
        Dictionary<string, string> RusMessages = new Dictionary<string, string>();

        public MessageBoxLocalizer() 
        {
            BuildResources();
        }

        private void BuildResources()
        {
            EngMessages.Add("ConfigsControllerInitError", $"Configs controller cannot be initialized!\r\nPlease check correctness of game path in App setting.");
            EngMessages.Add("PckgsInstalled", "Selected packages was installed!");
            EngMessages.Add("GamePathIncorrectCompiling", "Game path seems incorrect!\r\nTry anway?");
            EngMessages.Add("CompilingNotification", "Running this operation will clear all content from 'GII\\System\\Autorun' folder, " +
                "delete 'GOTHIC.EDITED.DAT' file and modify game archive!\r\n" +
                "Important: Do not close this app untill patching done!\r\nAre you ready?");
            EngMessages.Add("CopilationSuccess", "Game successfully patched!\r\nNow you can close App and start Gothic in normal way.");


            RusMessages.Add("ConfigsControllerInitError", $"Контроллер кофигурации мода не может быть инициализирован!\r\nПроверьте правильность пути приложеия.");
            RusMessages.Add("PckgsInstalled", "Выбраные моды были установлены!");
            RusMessages.Add("GamePathIncorrectCompiling", "Путь к игре выглядит неверным!\r\nВсёравно продолжить?");
            RusMessages.Add("CompilingNotification", "Выполнеие этой операции очистит содержимое 'GII\\System\\Autorun', " +
                "удалит 'GOTHIC.EDITED.DAT' и модифицирует игровой архив!\r\n" +
                "Важно: Не закрывайте приложение до окончаия операции!\r\nВы готовы?");
            RusMessages.Add("CopilationSuccess", "Игра удачно пропатчена!\r\nТеперь можно закрыть приложение и запустить Готику обычным путём.");
        }

        public string GetMessage(string key)
        {
            if(AppConfigsProvider.Configs.Language == "Rus") return RusMessages[key];
            else return EngMessages[key];
        }
    }
}
