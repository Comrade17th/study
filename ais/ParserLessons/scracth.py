import csv
comps = []
data = []
def write_to_csv_file(data):
    with open(f"file_name.csv", "w", newline='') as file:
        writer = csv.writer(file)
        writer.writerow(
            ("type",
            "title",
            "price",
            "saler",
            "buyer",
            "datetime",
            "datetime-end",
            "datetime-start",
            "status",
            "event",
            "actions")
        )
    for cort1 in data:
        with open(f"file_name.csv", "a", newline='') as file:
            writer = csv.writer(file)
            writer.writerow(
                (cort1[0],
                 cort1[1],
                 cort1[2],
                 cort1[3],
                 cort1[4],
                 cort1[5],
                 cort1[6],
                 cort1[7],
                 cort1[8],
                 cort1[9],
                 cort1[10],)
            )

for comp in comps:
    cort = (comp["type"],
            comp["title"],
            comp["price"],
            comp["saler"],
            comp["buyer"],
            comp["datetime"],
            comp["datetime-end"],
            comp["datetime-start"],
            comp["status"],
            comp["event"],
            comp["actions"])
    data.append(cort)

print(data[0])
print(data)