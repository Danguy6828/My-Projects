from Drink import Drink

class Order:
    def __init__(self):
        self._items = []

    def get_items(self):
        return self._items

    def get_num_items(self):
        return len(self._items)

    def get_total(self):
        for item in self._items:
            total = sum(item.get_total())
        return total

    def add_item(self, item:Drink):
        self._items.append(item)
        print('Drink Added')

    def remove_item(self, index:int):
        del self._items[int]
        print('Drink Removed')
