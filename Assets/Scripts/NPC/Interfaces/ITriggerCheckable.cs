public interface ITriggerCheckable
{
	bool isAggroed { get; set; }
	bool isWithinStrikingDistance { get; set; }

	void SetAggroStatus(bool isAggroed);
	void SetStrikingDistanceBool(bool isWithinStrikingDistance);
}