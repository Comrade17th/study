comps = []
data = []
for comp in comps:
    #print(f'{comp["type"]} -> {comp["title"]} -> {comp["price"]} -> {comp["saler"]} -> {comp["buyer"]} -> {comp["datetime"]} -> {comp["datetime-end"]} -> {comp["datetime-start"]} -> {comp["status"]} -> {comp["event"]} -> {comp["actions"]}')
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