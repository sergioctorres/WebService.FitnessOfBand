# WebService.FitnessOfBand
WebService para consumo do Aplicativo Mobile FitnessOfBand

## Wearable

InsertWearable(string identificatio)
- Insere a identificação do Wearable utilizado.

GetWearable()
- Consulta os Warables cadastrados.

## Information

InsertInformation(int Wearable_Id, DateTime InitialDateTime, DateTime FinishedDateTime, int InitialHeartRate, int FinalHeartRate, long InitialDistance, long FinalDistance, long InitialSteps, long FinalSteps, long InitialCalories, long FinalCalories)
- Insere as informações coletadas da pulseira durante o exercício.

GetInformation(int Id)
- Consulta as informações existentes de determinado Wearable.

GetLastInformations()
- Consulta as últimas 5 informações disponíveis

## RealTime

InsertRealTime(int Wearable_Id, DateTime CapturedDateTime, int HeartRate, double Speed, double Pace, long TotalDistance, long TotalSteps, long Calories)
- Insere os dados que foram coletados em tempo real do Wearable.