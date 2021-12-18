using System;
using System.Windows;
using ViewModelBase.Commands.ErrorHandlers;


namespace WpfLibrary;

public class ErrorHandle : IErrorCancelHandler, IErrorNotFoundHandler
{
    public void HandleCancel(OperationCanceledException ex)
    {
        if (ex.Message == "-1") return;
        MessageBox.Show(
            String.IsNullOrEmpty(ex.Message) || ex.Message == "A task was canceled." ?
                "�������� ������� ��������." : ex.Message,
            "������", MessageBoxButton.OK, MessageBoxImage.Asterisk);
    }

    public void HandleError(Exception ex) => MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

    public void HandleResultNotFound(ResultNotFoundException ex) =>
        MessageBox.Show("�� ������: \"" + ex.Message + "\"",
            "���������� �� �������", MessageBoxButton.OK, MessageBoxImage.Information);
}