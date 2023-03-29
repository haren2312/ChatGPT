using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using ChatGPT.ViewModels.Chat;
using ChatGPT.ViewModels.Layouts;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ChatGPT.ViewModels.Settings;

public class WorkspaceViewModel : ObservableObject
{
    private string? _name;
    private ObservableCollection<ChatViewModel> _chats;
    private ChatViewModel? _currentChat;
    private ObservableCollection<PromptViewModel> _prompts;
    private PromptViewModel? _currentPrompt;
    private ObservableCollection<LayoutViewModel> _layouts;
    private LayoutViewModel? _currentLayout;
    private string? _theme;
    private string? _layout;
    private bool _topmost;

    [JsonConstructor]
    public WorkspaceViewModel()
    {
        _chats = new ObservableCollection<ChatViewModel>();
        _prompts = new ObservableCollection<PromptViewModel>();
        _layouts = new ObservableCollection<LayoutViewModel>();
    }

    [JsonPropertyName("name")]
    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    [JsonPropertyName("chats")]
    public ObservableCollection<ChatViewModel> Chats
    {
        get => _chats;
        set => SetProperty(ref _chats, value);
    }

    [JsonPropertyName("currentChat")]
    public ChatViewModel? CurrentChat
    {
        get => _currentChat;
        set => SetProperty(ref _currentChat, value);
    }
    
    [JsonPropertyName("prompts")]
    public ObservableCollection<PromptViewModel> Prompts
    {
        get => _prompts;
        set => SetProperty(ref _prompts, value);
    }

    [JsonPropertyName("currentPrompt")]
    public PromptViewModel? CurrentPrompt
    {
        get => _currentPrompt;
        set => SetProperty(ref _currentPrompt, value);
    }

    [JsonPropertyName("layouts")]
    public ObservableCollection<LayoutViewModel> Layouts
    {
        get => _layouts;
        set => SetProperty(ref _layouts, value);
    }

    [JsonPropertyName("currentLayout")]
    public LayoutViewModel? CurrentLayout
    {
        get => _currentLayout;
        set => SetProperty(ref _currentLayout, value);
    }

    [JsonPropertyName("theme")]
    public string? Theme
    {
        get => _theme;
        set => SetProperty(ref _theme, value);
    }

    [JsonPropertyName("layout")]
    public string? Layout
    {
        get => _layout;
        set => SetProperty(ref _layout, value);
    }

    [JsonPropertyName("topmost")]
    public bool Topmost
    {
        get => _topmost;
        set => SetProperty(ref _topmost, value);
    }

    private ObservableCollection<ChatViewModel> CopyChats(out ChatViewModel? currentChat)
    {
        var chats = new ObservableCollection<ChatViewModel>();

        currentChat = null;

        foreach (var chat in _chats)
        {
            var chatCopy = chat.Copy();

            chats.Add(chatCopy);

            if (chat == _currentChat)
            {
                currentChat = chatCopy;
            }
        }

        return chats;
    }

    private ObservableCollection<PromptViewModel> CopyPrompts(out PromptViewModel? currentPrompt)
    {
        var prompts = new ObservableCollection<PromptViewModel>();

        currentPrompt = null;

        foreach (var prompt in _prompts)
        {
            var promptCopy = prompt.Copy();

            prompts.Add(promptCopy);

            if (prompt == _currentPrompt)
            {
                currentPrompt = promptCopy;
            }
        }

        return prompts;
    }

    private ObservableCollection<LayoutViewModel> CopyLayouts(out LayoutViewModel? currentLayout)
    {
        var layouts = new ObservableCollection<LayoutViewModel>();

        currentLayout = null;

        foreach (var layout in _layouts)
        {
            var layoutCopy = layout.Copy();

            layouts.Add(layoutCopy);

            if (layout == _currentLayout)
            {
                currentLayout = layoutCopy;
            }
        }

        return layouts;
    }

    public WorkspaceViewModel Copy()
    {
        return new WorkspaceViewModel
        {
            Name = _name,
            Chats = CopyChats(out var currentChat),
            CurrentChat = currentChat,
            Prompts = CopyPrompts(out var currentPrompt),
            CurrentPrompt = currentPrompt,
            Layouts = CopyLayouts(out var currentLayout),
            CurrentLayout = currentLayout,
            Theme = _theme,
            Layout = _layout,
            Topmost = _topmost,
        };
    }
}
