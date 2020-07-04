public interface IWorker{
    bool HandleCall(Call call);
    bool IsBusy();
}